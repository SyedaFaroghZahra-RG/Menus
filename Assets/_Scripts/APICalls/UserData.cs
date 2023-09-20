using System;
using System.Collections.Generic;

[Serializable]
public class UserData
{
    public class Address
    {
        public string address;
        public string city;
        public Coordinates coordinates;
        public string postalCode;
        public string state;
    }

    public class Bank
    {
        public string cardExpire;
        public string cardNumber;
        public string cardType;
        public string currency;
        public string iban;
    }

    public class Company
    {
        public Address address;
        public string department;
        public string name;
        public string title;
    }

    public class Coordinates
    {
        public double lat;
        public double lng;
    }

    public class Hair
    {
        public string color;
        public string type;
    }
        public int id;
        public string firstName;
        public string lastName;
        public string maidenName;
        public int age;
        public string gender;
        public string email;
        public string phone;
        public string username;
        public string password;
        public string birthDate;
        public string image;
        public string bloodGroup;
        public int height;
        public double weight;
        public string eyeColor;
        public Hair hair;
        public string domain;
        public string ip;
        public Address address;
        public string macAddress;
        public string university;
        public Bank bank;
        public Company company;
        public string ein;
        public string ssn;
        public string userAgent;
    
}