using System;
using System.Collections.Generic;
using System.Text;

namespace WebDockerDemo.Model.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public League League { get; set; }
        public List<Player> Players { get; set; }
    }
}