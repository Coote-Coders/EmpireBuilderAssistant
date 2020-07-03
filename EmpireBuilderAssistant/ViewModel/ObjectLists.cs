using EmpireBuilderAssistant.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Windows.Media;

namespace EmpireBuilderAssistant.ViewModel
{
    class ObjectLists
    {
        static public City allCities;
        static public bool ShowDebugButtons { get; }
        static public ObservableCollection<City> Cities { get; }
        static public ObservableCollection<Cargo> Cargos { get; }

        static private Random random = new Random();

        static ObjectLists()
        {
            ShowDebugButtons = false;
#if DEBUG
            ShowDebugButtons = true;
#endif

            allCities = new City("Show all pickups", 0, 0 );

            Cities = new ObservableCollection<City> {
                               new City("Atlanta" , 1774, 1121),
                               new City("Billings" , 817, 565),
                               new City("Birmingham" , 1673, 1141),
                               new City("Boise" , 503, 624),
                               new City("Boston" , 2161, 582),
                               new City("Buffalo" , 1882, 665),
                               new City("Calgary" , 674, 240),
                               new City("Cheyenne" , 891, 765),
                               new City("Chicago" , 1503, 766),
                               new City("Chihuahua" , 821, 1478),
                               new City("Cincinnati" , 1709, 882),
                               new City("Culiacan" , 751, 1678),
                               new City("Dallas" , 1232, 1279),
                               new City("Denver" , 892, 845),
                               new City("Des Moines" , 1334, 787),
                               new City("Detroit" , 1708, 725),
                               new City("Duluth" , 1366, 528),
                               new City("Durango" , 856, 1658),
                               new City("Fargo" , 1196, 505),
                               new City("Guadalajara" , 920, 1898),
                               new City("Hermosillo" , 578, 1421),
                               new City("Houston" , 1299, 1397),
                               new City("Jacksonville" , 1913, 1279),
                               new City("Jaurez" , 787, 1339),
                               new City("Kansas City" , 1299, 923),
                               new City("Knoxville" , 1741, 1022),
                               new City("Las Vegas" , 438, 1021),
                               new City("Los Angeles" , 297, 1101),
                               new City("Memphis" , 1504, 1123),
                               new City("Mexico City" , 1163, 1957),
                               new City("Miami" , 2015, 1498),
                               new City("Minneapolis" , 1332, 629),
                               new City("Monterrey" , 1095, 1596),
                               new City("Montreal" , 2024, 421),
                               new City("New Orleans" , 1506, 1354),
                               new City("New York" , 2055, 643),
                               new City("Norfolk" , 2052, 922),
                               new City("Oklahoma City" , 1200, 1140),
                               new City("Omaha" , 1232, 806),
                               new City("Philadelphia" , 2053, 723),
                               new City("Phoenix" , 579, 1222),
                               new City("Pittsburgh" , 1880, 785),
                               new City("Portland ME" , 2161, 460),
                               new City("Portland OR" , 257, 480),
                               new City("Raleigh" , 1948, 982),
                               new City("Regina" , 919, 302),
                               new City("Salt Lake City" , 611, 803),
                               new City("San Diego" , 337, 1203),
                               new City("San Francisco" , 193, 883),
                               new City("Santa Fe" , 824, 1122),
                               new City("Savannah" , 1914, 1199),
                               new City("Seattle" , 291, 379),
                               new City("St Louis" , 1470, 945),
                               new City("Sudbury" , 1746, 465),
                               new City("Tampa" , 1882, 1416),
                               new City("Tampico" , 1195, 1775),
                               new City("Toronto" , 1845, 599),
                               new City("Torreon" , 959, 1598),
                               new City("Vancouver" , 325, 276),
                               new City("Veracruz" , 1300, 1956),
                               new City("Washington DC" , 1984, 802),
                               new City("Winnepeg" , 1161, 364)};

            Cargos = new ObservableCollection<Cargo> {
                                new Cargo("Bauxite" , new List<string>{"Memphis"}),
                                new Cargo("Cars" , new List<string>{"Detroit", "Toronto" }),
                                new Cargo("Cattle" , new List<string>{"Billings", "Calgary", "Cheyenne", "Chihuahua", "Miami", "Regina" }),
                                new Cargo("Coal" , new List<string>{ "Cincinnati", "Duluth", "Salt Lake City", "Santa Fe"}),
                                new Cargo("Coffee" , new List<string>{"Veracruz" }),
                                new Cargo("Copper" , new List<string>{"Phoenix", "Portland OR" }),
                                new Cargo("Corn" , new List<string>{ "Des Moines", "Guadalajara", "Minneapolis", "St Louis" }),
                                new Cargo("Cotton" , new List<string>{"Dallas", "Savannah", "Torreon" }),
                                new Cargo("Fish" , new List<string>{"Boston", "Hermosillo", "Norfolk", "Portland OR", "Tampico", "Vancouver" }),
                                new Cargo("Fruit" , new List<string>{"San Diego", "San Francisco", "Tampa" }),
                                new Cargo("Imports" , new List<string>{"Montreal", "Norfolk", "Philadelphia", "San Francisco", "Veracruz" }),
                                new Cargo("Iron" , new List<string>{"Birmingham", "Duluth" }),
                                new Cargo("Lead" , new List<string>{"Boise", "Calgary", "Denver" }),
                                new Cargo("Machinery" , new List<string>{"Boston", "Buffalo", "Cincinnati", "Jacksonville", "Jaurez", "Knoxville", "Raleigh", "San Diego", "Toronto" }),
                                new Cargo("Nickel" , new List<string>{"Sudbury", "Vancouver" }),
                                new Cargo("Oats" , new List<string>{"Fargo", "Omaha" }),
                                new Cargo("Oil" , new List<string>{"Dallas", "Houston", "Oklahoma City", "Tampa" }),
                                new Cargo("Rice" , new List<string>{"Houston", "Oklahoma City" }),
                                new Cargo("Sheep" , new List<string>{"Billings", "Salt Lake City", "Torreon" }),
                                new Cargo("Silver" , new List<string>{"Durango" }),
                                new Cargo("Steel" , new List<string>{"Birmingham", "Monterrey" }),
                                new Cargo("Sugar" , new List<string>{"San Francisco" }),
                                new Cargo("Swine" , new List<string>{ "Des Moines", "St Louis" }),
                                new Cargo("Textiles" , new List<string>{"Durango", "Monterrey" }),
                                new Cargo("Tobacco" , new List<string>{"Raleigh", "Savannah" }),
                                new Cargo("Tourists" , new List<string>{"Chicago", "New York" }),
                                new Cargo("Uranium" , new List<string>{"Regina", "Santa Fe" }),
                                new Cargo("Wheat" , new List<string>{"Guadalajara", "Oklahoma City", "Omaha", "Winnepeg" }),
                                new Cargo("Wood" , new List<string>{"Portland OR", "Portland ME" })};
        }

        static public City FindCity(string name)
        {
            // Lookup city object by name
            foreach (City city in Cities)
            {
                if (city.Name == name)
                {
                    return city;
                }
            }

            // Opps was not found should not happen
            Debugger.Break();
            return null;
        }

        static public Cargo FindCargo(string name)
        {
            // Find cargo object by name
            foreach (Cargo cargo in Cargos)
            {
                if (cargo.Name == name)
                {
                    return cargo;
                }
            }

            // Opps was not found should not happen
            Debugger.Break();
            return null;
        }

        static public int GetRandomNumber(int max)
        {
            return random.Next(max);
        }
    }
}
