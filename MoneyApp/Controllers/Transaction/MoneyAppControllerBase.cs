using Microsoft.AspNetCore.Mvc;
using MoneyApp.Db.Repository.Transaction;
using MoneyApp.DB.Interface.Authorization;
using MoneyApp.DB.Repository.Authorization;
using MoneyApp.Interface.Transaction;
using MoneyApp.Other;
using MoneyApp.Other.State;
using MoneyApp.Other.State.Authorization;
using System;

namespace MoneyApp.Controllers.Transaction
{
    public abstract class MoneyAppControllerBase : Controller
    {
        private ICategoryRepository categoryRepository;
        private CategoryState categoryState;
        private ITypeTransactionRepository typeTransactionRepository;
        private ITransactionRepository transactionRepository;
        private TransactionState transactionState;
        private AccountState accountState;
        private TypeTransactionState typeTransactionState;
        private IUserRepository userRepository;
        private Auth auth;
        private  bool? isAdmin;
        public bool IsAdmin { get { if (isAdmin == null) return User.IsInRole("admin"); return isAdmin.Value; } set => isAdmin = value; }
        public Auth Auth
        {
            get
            {
                if (auth == null) Auth = new Auth();
                return auth;
            }
            set => auth = value;
        }

        public TypeTransactionState TypeTransactionState
        {
            get
            {
                if (typeTransactionState == null) TypeTransactionState = new TypeTransactionState();
                return typeTransactionState;
            } 
            set => typeTransactionState = value;
        }

        public AccountState AccountState
        {
            get
            {
                if (accountState == null) AccountState = new AccountState();
                return accountState;
            }
            set => accountState = value;
        }

        public ITypeTransactionRepository TypeTransactionRepository
        {
            get
            {
                if (typeTransactionRepository == null) TypeTransactionRepository = new TypeTransactionRepository();
                return typeTransactionRepository;
            }
            set => typeTransactionRepository = value;
        }

        public ITransactionRepository TransactionRepository
        {
            get
            {
                if (transactionRepository == null) TransactionRepository = new TransactionRepository();
                return transactionRepository;
            }
            set => transactionRepository = value;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null) CategoryRepository = new CategoryRepository();
                return categoryRepository;
            }
            set => categoryRepository = value;
        }

        public TransactionState TransactionState
        {
            get
            {
                if (transactionState == null) TransactionState = new TransactionState();
                return transactionState;
            }
            set => transactionState = value;
        }
        public CategoryState CategoryState
        {
            get
            {
                if (categoryState == null) CategoryState = new CategoryState();
                return categoryState;
            }
            set => categoryState = value;

        }

        public IUserRepository UserRepository 
        {
            get 
            {
                if (userRepository == null) UserRepository = new UserRepository();
                return userRepository;
            }
            set => userRepository = value;
        }
    }
}
