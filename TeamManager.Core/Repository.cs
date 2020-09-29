using System;
using System.Collections.Generic;
using System.Linq;
using TeamManager.Core;
using Utils;

namespace CdManager.Model
{
    /// <summary>
    /// Repository als Singleton, damit die Daten aus dem CSV-File nur einmal gelesen werden!
    /// </summary>
    public class Repository
    {
        private const string fileName = "Members.csv";

        private static Repository instance;

        List<Member> members;

        private Repository()
        {
            members = new List<Member>();
            LoadCdsFromCsv();
        }

        public static Repository GetInstance()
        {
            if (instance == null)
                instance = new Repository();

            return instance;
        }

        /// <summary>
        /// Lädt die Daten vom csv-File in die Collection
        /// </summary>
        private void LoadCdsFromCsv()
        {
            string[][] MembersCsv = fileName.ReadStringMatrixFromCsv(true);
            members = MembersCsv.Select(line => new Member { FirstName = line[0], LastName = line[1], BirthDate = DateTime.Parse(line[2]) })
                .ToList();
        }

        public void DeleteMember(Member member)
        {
            members.Remove(member);
        }

        /// <summary>
        /// Neue Cd in die Collection einfügen
        /// </summary>
        /// <param name="cd"></param>
        public void AddMember(Member member)
        {
            members.Add(member);
        }

        /// <summary>
        /// Liefert eine (neue!) Liste aller Cds
        /// Entkoppelt die zurückgelieferte Collektion von der Collection im Repository
        /// Beachte! Die Objekte selbst sind jedoch noch dieselben (clonen wäre erforderlich)!
        /// </summary>
        /// <returns></returns>
        public List<Member> GetAllMembers()
        {
            return members.ToList(); //Erstellt neue Liste!
        }
    }
}
