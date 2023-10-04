﻿using System;
using System.Collections.Generic;

    [Serializable]
    public class Coordinates
    {
        public string latitude;
        public string longitude;
    }
    [Serializable]
    public class Dob
    {
        public DateTime date;
        public int age;
    }
    [Serializable]
    public class Id
    {
        public string name;
        public string value;
    }
    [Serializable]
    public class Info
    {
        public string seed;
        public int results;
        public int page;
        public string version;
    }
    [Serializable]
    public class Location
    {
        public Street street;
        public string city;
        public string state;
        public string country;
        public object postcode;
        public Coordinates coordinates;
        public Timezone timezone;
    }
    [Serializable]
    public class Login
    {
        public string uuid;
        public string username;
        public string password;
        public string salt;
        public string md5;
        public string sha1;
        public string sha256;
    }
    [Serializable]
    public class Name
    {
        public string title;
        public string first;
        public string last;
    }
    [Serializable]
    public class Picture
    {
        public string large;
        public string medium;
        public string thumbnail;
    }
    [Serializable]
    public class Registered
    {
        public DateTime date;
        public int age;
    }
    [Serializable]
    public class Result
    {
        public string gender;
        public Name name;
        public Location location;
        public string email;
        public Login login;
        public Dob dob;
        public Registered registered;
        public string phone;
        public string cell;
        public Id id;
        public Picture picture;
        public string nat;
    }
    [Serializable]
    public class UserData
    {
        public List<Result> results;
        public Info info;
    }
    [Serializable]
    public class Street
    {
        public int number;
        public string name;
    }
    [Serializable]
    public class Timezone
    {
        public string offset;
        public string description;
    }

