﻿using AElf.Contracts.Consensus.AEDPoS;
using AElf.Contracts.MultiToken;
using AElf.Cryptography.ECDSA;
using AElf.Testing.TestBase;
using AElf.Types;

namespace AElf.Contracts.BingoGameContract
{
    public class Module : ContractTestModule<BingoGameContract>
    {
        
    }
    public class TestBase : ContractTestBase<Module>
    {
        // You can get address of any contract via GetAddress method, for example:
        // internal Address ContractAddress => GetAddress(DAppSmartContractAddressNameProvider.StringName);
        
        internal BingoGameContractContainer.BingoGameContractStub BingoGameContractStub { get; set; }
        internal BingoGameContractContainer.BingoGameContractStub UserStub { get; set; }
        internal TokenContractContainer.TokenContractStub TokenContractStub { get; set; }
        internal RandomNumberAccessorContractContainer.RandomNumberAccessorContractStub RandomNumberAccessorContractStub { get; set; }
        protected ECKeyPair DefaultKeyPair => Accounts[0].KeyPair;
        protected Address DefaultAddress => Accounts[0].Address;
        protected ECKeyPair UserKeyPair => Accounts[1].KeyPair;
        protected Address UserAddress => Accounts[1].Address;

        public TestBase()
        {
            BingoGameContractStub = GetBingoGameContractStub(DefaultKeyPair);
            UserStub = GetBingoGameContractStub(UserKeyPair);
            TokenContractStub = GetTokenContractTester(DefaultKeyPair);
            RandomNumberAccessorContractStub = GetRandomNumberAccessorContractStub(DefaultKeyPair);
        }

        internal BingoGameContractContainer.BingoGameContractStub GetBingoGameContractStub(ECKeyPair senderKeyPair)
        {
            return GetTester<BingoGameContractContainer.BingoGameContractStub>(ContractAddress, senderKeyPair);
        }

        internal TokenContractContainer.TokenContractStub GetTokenContractTester(ECKeyPair keyPair)
        {
            return GetTester<TokenContractContainer.TokenContractStub>(TokenContractAddress, keyPair);
        }

        internal RandomNumberAccessorContractContainer.RandomNumberAccessorContractStub GetRandomNumberAccessorContractStub(ECKeyPair keyPair)
        {   
            return GetTester<RandomNumberAccessorContractContainer.RandomNumberAccessorContractStub>(ConsensusContractAddress, keyPair);
        }
    }
    
}