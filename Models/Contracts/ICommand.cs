namespace Models
{
    using System;

    public interface ICommand
    {
        long AggregateId { get; set; }

        long IssuedBy { get; set; }

        DateTime IssuedOn { get; set; }
    }
}
