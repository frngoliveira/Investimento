﻿namespace Investimento.Domain._2._2_Entity
{
    public class Position
    {
        public string? PositionId { get; set; }
        public string? ProductId { get; set; }
        public string? ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public decimal Quantity { get; set; }
    }
}
