using FluentValidation;
using BarberShop.BL.DTOs;
using BarberShop.BL.Validations.Base;
using BarberShop.Domain.Contexts;
using BarberShop.Domain.Entities;
using BarberShop.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BarberShop.BL.DTOs.Global;
using BarberShop.Domain.Entities.Global;
using System.Linq; 

namespace BarberShop.BL.Validations.Global
{
    public class DemoValidator : BaseValidator<Demo>
    {
        private readonly IUnitOfWork<BaseDBContext> _uow;
        public DemoValidator(IUnitOfWork<BaseDBContext> uow)
        {
            _uow = uow;
            //
            RuleFor(x => x.Codigo)
                .NotEmpty()
                .WithMessage("NOT_EMPTY_FIELD")
                .MustAsync(BeUnique)
                .WithMessage("ALREADY_EXISTS")
                .MaximumLength(4)
                .WithMessage("EXCEED_MAX:4");
            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .WithMessage("NOT_EMPTY_FIELD")
                .MaximumLength(40)
                .WithMessage("EXCEED_MAX:40");

            /*       RuleFor(x => x.ChatRoomId)
                .MustAsync(Exists)
                .WithMessage("This chat room does not exist");*/
        }

        private async Task<bool> BeUnique(string codigo, CancellationToken arg2)
        {
            var repo = _uow.GetRepository<Demo>();
            var currentEntity = (await repo.Get(x => x.Codigo == codigo)).FirstOrDefault();

            return currentEntity == null;
        }

        private async Task<bool> Exists(Guid chatRoomId, CancellationToken arg2)
        {
            var chatRoom = await _uow.GetRepository<Demo>()
                            .GetById(chatRoomId);

            var chatRoomExists = chatRoom != null;

            return chatRoomExists;
        }
    }
}
