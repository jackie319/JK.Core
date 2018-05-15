using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JK.Core.Data
{
    public abstract class NopEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        protected NopEntityTypeConfiguration()
        {
            PostInitialize();
        }

        public void Configure(EntityTypeBuilder<T> builder)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }
    }
}
