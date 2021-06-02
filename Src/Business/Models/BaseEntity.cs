using System;
using System.ComponentModel;

namespace Business.Models

{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            UpdateAt = DateTime.Now;
            Deleted = false;
            Active = true;
        }

        public Guid Id { get; set; }
        [DisplayName("Dt. Criação")]
        public DateTime CreateAt { get; set; }
        [DisplayName("Dt. Alteração")]
        public DateTime UpdateAt { get; set; }
        [DisplayName("Deletado")]
        public bool Deleted { get; set; }
        [DisplayName("Ativo?")]
        public bool Active { get; set; }


    }
}