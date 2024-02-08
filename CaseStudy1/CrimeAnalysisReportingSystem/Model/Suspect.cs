using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisAndReportingSystem.Model
{
    internal class Suspect
    {
        private int suspectId;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string gender;
        private string contactInformation;

        public int SuspectId {  get { return suspectId; } set { suspectId = value; } }
        public string FirstName { get { return firstName;} set { firstName = value; } }
        public string LastName { get { return lastName;} set { lastName = value; } }
        public DateTime DateOfBirth { get {  return dateOfBirth; } set {  dateOfBirth = value; } }
        public string Gender { get {  return gender; } set {  gender = value; } }
        public string ContactInformation { get {  return contactInformation; } set {  contactInformation = value; } }

    }
}
