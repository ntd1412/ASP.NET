﻿using _20T1080027.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20T1080027.Web.Models
{
    public class CustomerSearchOutput : PaginationSearchOutput
    {
        public List<Customer> Data { get; set; }
    }
}