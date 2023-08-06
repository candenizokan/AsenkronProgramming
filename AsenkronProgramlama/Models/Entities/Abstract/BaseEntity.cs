using System;

namespace AsenkronProgramlama.Models.Entities.Abstract
{
    public class BaseEntity
    {
        public int ID { get; set; }

		private DateTime _createdDate = DateTime.Now;

		public DateTime CreatedDate
		{
			get { return _createdDate; }
			set { _createdDate = value; }
		}

		public DateTime? UpdateDate { get; set; }


	}
}
