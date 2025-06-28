using Cortex.Mediator.Commands;
using Mitsui.Sale.Application.Internals.DTOs;
using Mitsui.Sale.Domain.Model.Entities;
using Mitsui.Sale.Domain.Model.ValueObjects;
using Mitsui.Sale.Domain.Model.Enumerations;
using Mitsui.Sale.Domain.Repositories;
using Mitsui.Shared.Domain.Repositories;

namespace Mitsui.Sale.Application.Internals.Commands;

/// <summary>
/// Handles bill creation.
/// </summary>
public class CreateBillCommandHandler : ICommandHandler<CreateBillCommand>
{
    private readonly IBillRepository _billRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateBillCommandHandler(IBillRepository billRepository, IUnitOfWork unitOfWork)
    {
        _billRepository = billRepository;
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc />
    public async Task<BillResource> Handle(CreateBillCommand command, CancellationToken cancellationToken)
    {
        if (command.Amount <= 0)
            throw new InvalidOperationException("Amount must be greater than zero");
        if (command.Emission < DateTime.UtcNow.Date)
            throw new InvalidOperationException("Emission date cannot be in the past");
        if (!Enum.IsDefined(typeof(EService), command.ServiceId))
            throw new InvalidOperationException("Invalid service identifier");

        var invoice = new Invoice { SerialNumber = command.SerialNumber, SequentialNumber = command.SequentialNumber };
        var existing = await _billRepository.FindByInvoiceAsync(invoice);
        if (existing != null)
            throw new InvalidOperationException("Invoice already exists");

        var bill = new Bill
        {
            Customer = command.Customer,
            ServiceId = command.ServiceId,
            Plate = command.Plate,
            Emission = command.Emission,
            Invoice = invoice,
            Amount = command.Amount
        };

        await _billRepository.AddAsync(bill);
        await _unitOfWork.CompleteAsync();

        return new BillResource
        {
            BillNumber = bill.BillNumber,
            Customer = bill.Customer,
            ServiceId = bill.ServiceId,
            Emission = bill.Emission,
            SerialNumber = bill.Invoice.SerialNumber,
            SequentialNumber = bill.Invoice.SequentialNumber,
            Amount = bill.Amount
        };
    }

    async Task ICommandHandler<CreateBillCommand>.Handle(CreateBillCommand command, CancellationToken cancellationToken)
    {
        await Handle(command, cancellationToken);
    }
}