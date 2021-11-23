using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BWS.Clients
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<BWSDay> BWSWeeks { get; set; }
    }
    public class BWSDay
    {
        public string Name { get; set; }
        public virtual int Type { get; }
    }
    public class BWSDayNew : BWSDay
    {
        public override int Type { get { return 0; } }
    }
    public class BWSDay1 : BWSDay
    {
        public override int Type { get { return 1; } }
        public Exercise Exercise1 { get; set; }
    }
    public class BWSDay2 : BWSDay1
    {
        public override int Type { get { return 2; } }
        public Exercise Exercise2 { get; set; }
    }
    public class BWSDay3 : BWSDay2
    {
        public override int Type { get { return 3; } }
        public Exercise Exercise3 { get; set; }
    }
    public class Exercise
    {
        public string Name { get; set; }
        public string Reps { get; set; }
        public string CoachComment { get; set; }
        public string Comment { get; set; }
    }
}
