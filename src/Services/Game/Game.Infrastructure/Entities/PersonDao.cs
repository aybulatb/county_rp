using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class PersonDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [MaxLength(32)]
        public string Name { get; set; }

        public int PlayerId { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }

        public DateTimeOffset LastVisitDate { get; set; }

        [MaxLength(16)]
        public string AdminLevelId { get; set; }

        [MaxLength(16)]
        public string FactionId { get; set; }

        public int? GangId { get; set; }

        public bool Leader { get; set; }

        public int Rank { get; set; }

        [NotMapped]
        public float[] Position
        {
            get { return JsonConvert.DeserializeObject<float[]>(_Position); }
            set { _Position = JsonConvert.SerializeObject(value); }
        }

        public int CommonInventoryId { get; set; }

        public int PocketsInventoryId { get; set; }

        [Column("Position")]
        public string _Position { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public PersonDao()
        {
        }

        public PersonDao(
            int id,
            string name,
            int playerId,
            DateTimeOffset registrationDate,
            DateTimeOffset lastVisitDate,
            string adminLevelId,
            string factionId,
            int? gangId,
            bool leader,
            int rank,
            float[] position,
            int commonInventoryId,
            int pocketsInventoryId
        )
        {
            Id = id;
            Name = name;
            PlayerId = playerId;
            RegistrationDate = registrationDate;
            LastVisitDate = lastVisitDate;
            AdminLevelId = adminLevelId;
            FactionId = factionId;
            GangId = gangId;
            Leader = leader;
            Rank = rank;
            Position = position;
            CommonInventoryId = commonInventoryId;
            PocketsInventoryId = pocketsInventoryId;
        }
    }
}
