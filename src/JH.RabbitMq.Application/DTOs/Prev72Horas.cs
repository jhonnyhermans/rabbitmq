using System;
using System.Collections.Generic;
using System.Text;

namespace JH.RabbitMq.Application.DTOs
{

    public class Rootobject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public DateTime date { get; set; }
        public DateTime date_br { get; set; }
        public Rain rain { get; set; }
        public Wind wind { get; set; }
        public Temperature temperature { get; set; }
    }

    public class Rain
    {
        public decimal precipitation { get; set; }
    }

    public class Wind
    {
        public decimal velocity { get; set; }
        public string direction { get; set; }
        public decimal directionDegrees { get; set; }
        public decimal gust { get; set; }
    }

    public class Temperature
    {
        public decimal temperature { get; set; }
    }

}
