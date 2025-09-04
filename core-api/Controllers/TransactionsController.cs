using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await _transactionsService.GetTransactions();
            return transactions is not null ? Ok(transactions) : NotFound();
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var transaction = await _transactionsService.GetTransactionById(id);
            return transaction is not null ? Ok(transaction) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
        {
            var createdTransaction = await _transactionsService.CreateTransaction(transaction);
            return Created("api/transactions/{id}", createdTransaction);
        }
    }
}