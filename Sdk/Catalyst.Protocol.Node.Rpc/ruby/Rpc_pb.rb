# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: Rpc.proto

require 'google/protobuf'

Google::Protobuf::DescriptorPool.generated_pool.build do
  add_message "Catalyst.Protocol.Rpc.Node.PingRequest" do
    optional :ping, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.PongResponse" do
    optional :pong, :bool, 2
  end
  add_message "Catalyst.Protocol.Rpc.Node.VersionRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.VersionResponse" do
    optional :version, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetInfoRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetInfoResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.CreateWalletRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.CreateWalletResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.ListWalletRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.ListWalletResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.CreateAddressRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.CreateAddressResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetAddressRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetAddressResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.ListAddressRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.ListAddressResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.ValidateAddressRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.ValidateAddressResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetBalanceRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetBalanceResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.CreateRawTransactionRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.CreateRawTransactionResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SignRawTransactionRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SignRawTransactionResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.DecodeRawTransactionRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.DecodeRawTransactionResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.BroadcastRawTransactionRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.BroadcastRawTransactionResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SendToRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SendToResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SendToFromRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SendToFromResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SendManyRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SendManyResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SendFromManyRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SendFromManyResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.AddNodeRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.AddNodeResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetPeerListRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetPeerListResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetPeerInfoRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetPeerInfoResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetConnectionCountRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetConnectionCountResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetDeltaRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetDeltaResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetMempoolRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.GetMempoolResponse" do
    map :info, :string, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SignMessageRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.SignMessageResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.VerifyMessageRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.VerifyMessageResponse" do
    optional :query, :string, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.ServiceStatusRequest" do
    optional :query, :bool, 1
  end
  add_message "Catalyst.Protocol.Rpc.Node.ServiceStatusResponse" do
    optional :query, :string, 1
  end
end

module Catalyst
  module Protocol
    module Rpc
      module Node
        PingRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.PingRequest").msgclass
        PongResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.PongResponse").msgclass
        VersionRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.VersionRequest").msgclass
        VersionResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.VersionResponse").msgclass
        GetInfoRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetInfoRequest").msgclass
        GetInfoResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetInfoResponse").msgclass
        CreateWalletRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.CreateWalletRequest").msgclass
        CreateWalletResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.CreateWalletResponse").msgclass
        ListWalletRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.ListWalletRequest").msgclass
        ListWalletResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.ListWalletResponse").msgclass
        CreateAddressRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.CreateAddressRequest").msgclass
        CreateAddressResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.CreateAddressResponse").msgclass
        GetAddressRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetAddressRequest").msgclass
        GetAddressResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetAddressResponse").msgclass
        ListAddressRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.ListAddressRequest").msgclass
        ListAddressResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.ListAddressResponse").msgclass
        ValidateAddressRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.ValidateAddressRequest").msgclass
        ValidateAddressResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.ValidateAddressResponse").msgclass
        GetBalanceRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetBalanceRequest").msgclass
        GetBalanceResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetBalanceResponse").msgclass
        CreateRawTransactionRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.CreateRawTransactionRequest").msgclass
        CreateRawTransactionResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.CreateRawTransactionResponse").msgclass
        SignRawTransactionRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SignRawTransactionRequest").msgclass
        SignRawTransactionResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SignRawTransactionResponse").msgclass
        DecodeRawTransactionRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.DecodeRawTransactionRequest").msgclass
        DecodeRawTransactionResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.DecodeRawTransactionResponse").msgclass
        BroadcastRawTransactionRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.BroadcastRawTransactionRequest").msgclass
        BroadcastRawTransactionResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.BroadcastRawTransactionResponse").msgclass
        SendToRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SendToRequest").msgclass
        SendToResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SendToResponse").msgclass
        SendToFromRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SendToFromRequest").msgclass
        SendToFromResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SendToFromResponse").msgclass
        SendManyRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SendManyRequest").msgclass
        SendManyResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SendManyResponse").msgclass
        SendFromManyRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SendFromManyRequest").msgclass
        SendFromManyResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SendFromManyResponse").msgclass
        AddNodeRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.AddNodeRequest").msgclass
        AddNodeResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.AddNodeResponse").msgclass
        GetPeerListRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetPeerListRequest").msgclass
        GetPeerListResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetPeerListResponse").msgclass
        GetPeerInfoRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetPeerInfoRequest").msgclass
        GetPeerInfoResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetPeerInfoResponse").msgclass
        GetConnectionCountRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetConnectionCountRequest").msgclass
        GetConnectionCountResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetConnectionCountResponse").msgclass
        GetDeltaRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetDeltaRequest").msgclass
        GetDeltaResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetDeltaResponse").msgclass
        GetMempoolRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetMempoolRequest").msgclass
        GetMempoolResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.GetMempoolResponse").msgclass
        SignMessageRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SignMessageRequest").msgclass
        SignMessageResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.SignMessageResponse").msgclass
        VerifyMessageRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.VerifyMessageRequest").msgclass
        VerifyMessageResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.VerifyMessageResponse").msgclass
        ServiceStatusRequest = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.ServiceStatusRequest").msgclass
        ServiceStatusResponse = Google::Protobuf::DescriptorPool.generated_pool.lookup("Catalyst.Protocol.Rpc.Node.ServiceStatusResponse").msgclass
      end
    end
  end
end