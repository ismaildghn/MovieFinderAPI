using DVDRentalAPI.Application.DTOs.Actor;
using DVDRentalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalAPI.Application.DTOs.Film
{
    public class ListFilm
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Language Language { get; set; }
        public int ReleaseYear { get; set; }
        public int Length { get; set; }
        public float Rating { get; set; }
        public List<ListActor> Actors { get; set; }
    }
}

