//generated by Blazor.Sharp.Generator
using Breeze.Sharp;
using System;

namespace BlazorBoilerplate.Shared.Dto.Db
{
    public partial class Todo : BaseEntity
    {

        public Int64 Id
        {
            get { return GetValue<Int64>(); }
            set { SetValue(value); }
        }

        public Guid CreatedBy
        {
            get { return GetValue<Guid>(); }
            set { SetValue(value); }
        }

        public DateTime CreatedOn
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        public Boolean IsCompleted
        {
            get { return GetValue<Boolean>(); }
            set { SetValue(value); }
        }

        public Boolean IsDeleted
        {
            get { return GetValue<Boolean>(); }
            set { SetValue(value); }
        }

        public Guid ModifiedBy
        {
            get { return GetValue<Guid>(); }
            set { SetValue(value); }
        }

        public DateTime ModifiedOn
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        public String Title
        {
            get { return GetValue<String>(); }
            set { SetValue(value); }
        }

   }
}