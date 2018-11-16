using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintingHouse.WebUI.Models
{
	public class PaperItem
	{
		public PaperFullType Id { get; set; }
		public string Name { get; set; }
	}
}