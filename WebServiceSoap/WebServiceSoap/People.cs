﻿using System;
using System.Collections.Generic;

namespace WebServiceSoap
{
    //Generate by Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
    public partial class People
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
