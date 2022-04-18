
namespace L06HandsOn.Models{
    public class Alien{
        public int Arms {get; set;}
        public int Heads {get; set;}
        public int Legs {get; set;}
        public DateTime BirthDate {get; set;}
        public enum Planets { Mercury, Venus, Earth, Mars, WhatOnceWas, Jupiter, Saturn, Neptune, Uranus, TheUnappreciatedPluto}
    }
}