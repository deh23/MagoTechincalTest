﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 10/10/2020 12:58:24
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace MagoTechincalTest
{
    public partial class Reservation {

        public Reservation()
        {
            OnCreated();
        }

        public virtual int Id { get; set; }

        public virtual string PlaneType { get; set; }

        public virtual int Slots { get; set; }

        public virtual int PlaneId { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}