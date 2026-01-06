using NotesApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NotesApp.Dtos.NoteDtos
{
  //    DTO = Data Transfer Object === објект што служи само за пренос на податоци
  //    меѓу: клиент ↔️ API   и    Controller ↔️ Service
  //    DTO sodrzi samo informacii sto trebaat, bez EF logika, bez navigacii i pobezbeden API
  //    API SEKOGAS VRAKJA DTO
    public class NoteDto
    {
        public string Text { get; set; }
        public Priority Priority { get; set; }
        public Tag Tag { get; set; }
        public string UserFullName { get; set; }

    }
}
