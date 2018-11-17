﻿using System;
using Grpc.Core;
using System.Threading;
using ADL.Rpc.Proto.Service;
using System.Threading.Tasks;

namespace ADL.Rpc.Server
{
    public class RpcServer : IRpcServer
    {
        private CancellationTokenSource TokenSource { get; set; }
        private Task ServerTask { get; set; }
        private Grpc.Core.Server Server { get; set; }
        private IRpcSettings Settings { get; set; }

        public void StartServer(IRpcSettings settings )
        {
            Settings = settings;
            Server = new Grpc.Core.Server
            {
                Services = { RpcService.BindService(new RpcServerImpl()) },
                Ports = { new ServerPort(Settings.BindAddress, Settings.Port, ServerCredentials.Insecure) }
            };
            TokenSource = new CancellationTokenSource();
            ServerTask = RunServiceAsync(Server, TokenSource.Token);
        }
        
        public void StopServer()
        {
            Console.WriteLine("Dispose started ");
            AwaitCancellation(TokenSource.Token);
//            TokenSource.Cancel();
            try
            {
                ServerTask.Wait();
            }
            catch (AggregateException)
            {
                Console.WriteLine("RpcServer shutdown canceled");
            }
            Console.WriteLine("RpcServer shutdown");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private static Task AwaitCancellation(CancellationToken token)
        {
            var taskSource = new TaskCompletionSource<bool>();
            token.Register(() => taskSource.SetResult(true));
            return taskSource.Task;
        }

        /// <summary>
        ///  Starts the RpcService
        /// </summary>
        /// <param name="server"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private static async Task RunServiceAsync(Grpc.Core.Server server,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            server.Start();
            Console.WriteLine("Rpc Server started, listening on " + server.Ports.ToString());
            await AwaitCancellation(cancellationToken);
            await server.ShutdownAsync();
        }
    }
}