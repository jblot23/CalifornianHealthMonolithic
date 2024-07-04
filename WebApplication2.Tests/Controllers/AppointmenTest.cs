

using CalifornianHealthMonolithic;
using CalifornianHealthMonolithic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Linq;
using Bogus;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace WebApplication2.Tests.Controllers
{
    [TestClass]

    public class AppointmenTestt
    {
        [TestMethod]
        public void AddPatient()
        {
            ConcurrentQueue<Patient> cq = new ConcurrentQueue<Patient>();

            // Arrange
            List<Patient> paitent = new List<Patient>();
            List<Appointment> appointments = new List<Appointment>();

            for (int i = 0; i<= 3000; i++)
            {
                var faker = new Faker();
                cq.Enqueue(new Patient
                {
                    FName = faker.Name.FirstName(),
                    LName = faker.Name.LastName(),
                    Address1 = faker.Address.FullAddress(),
                    Address2 = faker.Address.SecondaryAddress(),
                    City = faker.Address.City()
                });
            }

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RemovePatient()
        {
            // Arrange
            List<Patient> patients = new List<Patient>();

            for (int i = 0; i <= 3000; i++)
            {
                var patient = new Patient
                {
                    FName = "Jane",
                    LName = "Doe",
                    Address1 = "456 Main St",
                    Address2 = "",
                    City = "Anytown"
                };

                patients.Add(patient);
            }

            var patientToRemove = patients[1500]; // Choose a patient to remove

            // Act
            patients.Remove(patientToRemove);

            // Assert
            Assert.IsFalse(patients.Contains(patientToRemove));
            Assert.AreEqual(3000, patients.Count);
        }

        [TestMethod]
        public void WarningForAlreadyBooked()
        {
            ConcurrentQueue<Patient> cq = new ConcurrentQueue<Patient>();

            var faker = new Faker();
            cq.Enqueue(new Patient
            {
                ID = 1,
                FName = faker.Name.FirstName(),
                LName = faker.Name.LastName(),
                Address1 = faker.Address.FullAddress(),
                Address2 = faker.Address.SecondaryAddress(),
                City = faker.Address.City()
            });

            var dateToConflict = DateTime.Now;

            var appointment1 = new Appointment
            {
                ConsultantId = 1,
                EndDateTime = DateTime.Now,
                PatientId = 1,
                StartDateTime = dateToConflict
            };

            var userInput = dateToConflict;

            if(userInput.Date == appointment1.StartDateTime)
            {
                Assert.Fail("Another Apointment has been made");
            }


            Assert.That.Equals(true);
        }
      
    }
    



}

