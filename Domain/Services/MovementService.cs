using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.Interfaces;
using Domain.Aggregates.Customers.Interfaces;
using Domain.Aggregates.Movements;
using Domain.Aggregates.Movements.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public sealed class MovementService : IMovementService
    {
        public readonly IMovementRepository _movementRepository;
        public readonly IMovementQuery _movementQuery;
        public readonly IAccountQuerie _accountQuerie;
        public readonly IAccountRepository _accountRepository;
        public readonly ICustomerQuery _customerQuery;

        public MovementService(IMovementRepository movementRepository, IAccountQuerie accountQuerie, IAccountRepository accountRepository, IMovementQuery movementQuery, ICustomerQuery customerQuery)
        {
            _movementRepository = movementRepository;
            _accountQuerie = accountQuerie;
            _accountRepository = accountRepository;
            _movementQuery = movementQuery; 
            _customerQuery = customerQuery;
        }

        public Task<Movement> Insert(Movement movement)
        {
            //Verificar eistencia de cuenta
            var accountSelect = GetAccount(movement.accountId);

            //Verificar eistencia de cliente
            GetCustomer(accountSelect.customerID);

            //Calcula el tipo y asigana valores
            ProcessValidation(accountSelect, movement);

            return _movementRepository.Insert(movement);
        }

        public Task<List<Movement>> GetAllMovementsByCurrentDay(DateTime date)
        {
            return _movementQuery.GetAllMovementsByCurrentDay(date);
        }

        public Account GetAccount(int id)
        {
            var account = _accountQuerie.GetById(id).Result;

            return account;
        }

        public void GetCustomer(int id)
        {
            var customerSelect = _customerQuery.GetById(id);

            if (customerSelect == null)
                throw new Exception("The Customer not eists");
        }

        public void ProcessValidation(Account accountSelect, Movement movement)
        {
            //Inciar operacion si el valor es mayor a 0
            if (accountSelect != null && movement.value > 0)
            {
                //Si el tipo de movimiento es consignacion aumentar el valor de la cuenta seleccionada
                if (movement.typeMovement == Enums.TypeMovement.Consignment)
                {
                    accountSelect.balance += movement.value;
                }

                //En caso contrario si es retiro disminuir el valor de la cuenta
                if (movement.typeMovement == Enums.TypeMovement.Withdrawal)
                {
                    accountSelect.balance -= movement.value;

                    if (accountSelect.balance < 0)
                        throw new Exception("Value can't be less tha 0");
                }

                _accountRepository.Update(accountSelect);
            }
            else
            {
                throw new Exception("Verify the eists account or the value for transaction");
            }
        }
    }
}
