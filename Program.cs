﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Reflection;
using System.Transactions;

namespace LanghamHotel
{
    class Program
    {            //Create Main method
        static void Main(string[] args)
        {
            // create try
            try
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(folderPath, "HotelManagement.txt");

                HotelRooms room = new HotelRooms();
                char ans = 'n';

                //create do Main interface
                do
                {
                    Console.WriteLine("************************************************");
                    Console.WriteLine("LANGHAM HOTEL MANAGEMENT SYSTEM \n                MENU");
                    Console.WriteLine("************************************************");
                    Console.WriteLine(" \t\n 1. Add Rooms " + "\t\n 2. Display Rooms " + "\t\n 3. Allocate Rooms " +
                                      "\t\n 4. DeAllocate Rooms " + "" + "\t\n 5. Display Room Allocation Details" +
                                      "\t\n 6. Billing" + "\t\n 7. Save the Room Allocation to a File" +
                                      "\t\n 8. Show the Room Allocation from File" + "\t\n 9. Exit");
                    Console.WriteLine("*************************************************");
                    Console.Write("\nPlease Enter Your Choice number here: ");
                    int choiceNum = Convert.ToInt32(Console.ReadLine());
                    switch (choiceNum)
                    {
                        case 1:
                            //Option1 - function call
                            room.AddRooms();
                            break;

                        case 2:
                            //Option2 - function call
                            room.DisplayRooms();

                            break;

                        case 3:
                            //Option3 - function call
                            room.AllocateRooms();
                            break;

                        case 4:
                            //Option4 - function call
                            room.DeAllocateRooms();
                            break;

                        case 5:
                            //Option5 - function call
                            room.DisplayRoomAllocation();
                            break;

                        case 6:
                            //Option6 - function call
                            Console.WriteLine("Billing is under construction....Billing landing  soon....!!!");
                            break;
                        case 7:
                            //Option7 -function call
                            room.SaveRoomAllocation();
                            break;
                        case 8:
                            //Option8 - function call
                            room.ShowRoomAllocation();
                            break;
                        case 9:
                            //Option9 - function call
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Please check your option:");
                            break;

                    }

                    //  repeats the application menu if you want perform more 
                    Console.Write("Please Enter your choice to use application again (y/n):");
                    ans = Convert.ToChar(Console.ReadLine());
                } while (ans == 'y');

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception has been handeled " + ex.Message);
            }


        }
        //create class HotelRooms
        class HotelRooms
        {

            List<HotelRooms> Rooms = new List<HotelRooms>();
            List<HotelRooms> CustomerName = new List<HotelRooms>();
            private string fielpath;
            private string filepath;

            public int roomId { get; set; }
            public string? roomName { get; set; }
            public string? name { get; set; }
            public HotelRooms(int roomId, string? roomName, string? name)
            {
                this.roomId = roomId;
                this.roomName = roomName;
                this.name = name;
            }
            public HotelRooms(int roomId, string? roomName)
            {
                this.roomId = roomId;
                this.roomName = roomName;
            }
            public HotelRooms()
            {

            }
            // method addrooms
            public void AddRooms()
            {

                Console.Write("How many room need to be added: ");
                int num = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < num; i++)
                {
                    Console.Write("Enter Room Id ");
                    var result = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Room type (single/double/family ) ");
                    var result1 = Console.ReadLine();

                    HotelRooms newroom = new HotelRooms(result, result1);
                    Rooms.Add(newroom);

                }


            }
            //method displayrooms
            public void DisplayRooms()
            {
                Console.WriteLine(" \nThank you!!\t\nLangham Hotel Rooms Information \n");
                foreach (HotelRooms newroom in Rooms)
                {
                    Console.WriteLine("Available Rooms : " + " Room Id -  " + newroom.roomId + " \tRoom Type - " + newroom.roomName);
                }


            }
            //method allocaterooms
            public void AllocateRooms()
            {
                Console.Write("Enter s/d/f to check  which type rooms(single/double/family) want to allocate in hotel : ");
                var result = Console.ReadLine();
                var searchResults = Rooms.Where(n => n.roomName.Contains(result)).ToList();
                if (searchResults.Count == 0)
                {
                    Console.WriteLine("No Results Were Found");
                }
                else

                {
                    Console.WriteLine("The Following Results Were Found: \n");
                }
                foreach (HotelRooms arooms in searchResults)
                {
                    Console.WriteLine("Available  your choosen   rooms : " + "Room Id - " + arooms.roomId + " Room type - " + arooms.roomName);
                }
                Console.Write("How many room need to be allocated: ");
                int num = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= num; i++)
                {
                    Console.Write("Enter Room Id : ");
                    var result1 = Convert.ToInt32(Console.ReadLine());
                    //Console.Write("Enter Room type (single/double/family ) ");
                    //var result2 = Console.ReadLine();
                    Console.Write("Enter Customer name : ");
                    var result3 = Console.ReadLine();
                    Console.Write("Enter an index of allocate room ID: ");
                    var index = Convert.ToInt32(Console.ReadLine());
                    index--;

                    HotelRooms Customer = new HotelRooms(result1, result, result3);
                    CustomerName.Add(Customer);
                    Rooms.RemoveAt(index);
                    Console.WriteLine("Room allocated to  " + result3);


                }



            }
            // method deallocaterooms
            public void DeAllocateRooms()
            {
                Console.Write("How many room need to be allocated: ");
                int num = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= num; i++)
                {
                    Console.Write("Enter customer name  which  rooms want to deallocate in hotel ");
                    var result = Console.ReadLine();
                    var searchResults = CustomerName.Where(n => n.name.Contains(result)).ToList();
                    if (searchResults.Count == 0)
                    {
                        Console.WriteLine("No Results Were Found");
                    }
                    else

                    {
                        Console.WriteLine("The Following Results Were Found: \n");

                        foreach (HotelRooms arooms in searchResults)
                        {
                            Console.WriteLine("Available  your choosen   rooms : " + "Room Id - " + arooms.roomId + " Room type - " + arooms.roomName + " Customer name " + arooms.name);
                        }
                        Console.Write("Enter Room Id you want to deallocate : ");
                        var result1 = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter an index of deallocate room ID: ");
                        var index = Convert.ToInt32(Console.ReadLine());
                        index++;

                        Console.WriteLine("Room deallocated : \troom id : " + result1 + " Customer name: " + result);
                    }
                }

            }
            //method displayroomallocation
            public void DisplayRoomAllocation()
            {
                foreach (HotelRooms cus in CustomerName)
                {
                    Console.WriteLine("Allocated Rooms : \t" + " Room Id -  " + cus.roomId + " Room Type - " + cus.roomName + " Customer name " + cus.name);

                }
                Console.WriteLine("\n");
                foreach (HotelRooms newroom in Rooms)
                {

                    Console.WriteLine("Available Rooms after allocation : " + " Room Id - " + newroom.roomId + " \tRoom Type - " + newroom.roomName);

                }

            }
            //method saveroomallocation
            public void SaveRoomAllocation()
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                string filepath = Path.Combine(folderPath, "lhms_studentid.txt");

                // Check if file exists

                //  if (!File.Exists(filepath)) 
                //  {


                string sDateTime = DateTime.Now.ToString();

                using (StreamWriter sw = File.CreateText(filepath))
                {

                    foreach (HotelRooms cus in CustomerName)
                    {

                        sw.WriteLine("Allocated Rooms : " + "Customer name - " + cus.name + " Room Id - " + cus.roomId + " \tRoom Type - " + cus.roomName);

                    }
                    sw.Write(sDateTime);
                    Console.WriteLine("lhms_studentid.txt” created successfully!");
                    sw.Flush();
                    sw.Close();

                    //    }

                    Console.WriteLine("Data saved in lhms_studentid.txt !!");

                    // } else
                    //{ 
                    //       Console.WriteLine("lhms_studentid.txt already exists.");

                }




            }
            public void ShowRoomAllocation()
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                string filepath = Path.Combine(folderPath, "lhms_studentid.txt");


                string path1 = @"C:\Users\makum\OneDrive\Pictures\lhms_studentid.txt";
                string All_text = File.ReadAllText(path1);
                Console.WriteLine(All_text);

                string src = @"C:\Users\makum\OneDrive\Pictures\lhms_studentid.txt";
                string dest = @"C:\Users\makum\OneDrive\Pictures\lhms_studentid_Backup.txt";
                File.Copy(src, dest);
                Console.WriteLine("File has been backup");

                // string path2 = @"D:\Filehandle\lhms_studentid.txt";
                Console.WriteLine("Enter y for delete n for dont delete");
                char ch = Convert.ToChar(Console.ReadLine());
                if (ch == 'y')
                {
                    File.Delete(filepath);
                    Console.WriteLine("File has been deleted");
                }
                else if (ch == 'n')
                {
                    Console.WriteLine("Please dont delete file thank you ");
                }

            }
        }

    }
}

