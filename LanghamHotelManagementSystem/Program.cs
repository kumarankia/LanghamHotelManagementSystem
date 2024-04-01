using Microsoft.VisualBasic.FileIO;
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
                                      "\t\n 4. Re Allocate Rooms " + "" + "\t\n 5. Display Room Allocation Details" +
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
                Console.WriteLine("Exception has been handeled "+ex.Message); 
            }


        }
                     //create class HotelRooms
        class HotelRooms
        {
            
            List<HotelRooms> Rooms = new List<HotelRooms>();
            private string fielpath;
            private string filepath;

            public int roomId { get; set; }
            public string? roomName { get; set; }
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
                    int num=Convert.ToInt32(Console.ReadLine());
                for (int i=0; i < num; i++)
                {
                    Console.Write("Enter Room Id ");
                    var result= Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Room type (single/double/family ) ");
                    var result1=Console.ReadLine();

                    HotelRooms newroom = new HotelRooms(result ,result1);
                    Rooms.Add(newroom);

                }
                
              
            }
                  //method displayrooms
            public void DisplayRooms()
            {
                    Console.WriteLine(" \nThank you!!\t\nLangham Hotel Rooms Information \n");
                foreach (HotelRooms newroom in Rooms)
                {
                    Console.WriteLine("Available Rooms : "+ " Room Id -  "+newroom.roomId+ " \tRoom Type - "+newroom.roomName);
                }
                
                
            }
                   //method allocaterooms
           public void AllocateRooms()
           {
                   Console.Write("Enter s/d/f to check  which type rooms(single/double/family) want to allocate in hotel : ");
                   var result=Console.ReadLine();
                   var searchResults = Rooms.Where(n => n.roomName.Contains(result)).ToList();
                if (searchResults.Count==0)
                {
                    Console.WriteLine("No Results Were Found");
                }
                else

                {
                    Console.WriteLine("The Following Results Were Found: \n");
                foreach (HotelRooms arooms in searchResults)
                {                     
                    Console.WriteLine("Available  your choosen   rooms : "+"Room Id - "+arooms.roomId + " Room type - " + arooms.roomName);
                }
                    Console.WriteLine("From available your choosen rooms  select  room id you want to allocate ");
                    var result2= Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Customer Name to Allocate this room : ");
                    string? name = Console.ReadLine();

                    Console.Write("Enter an index of Room ID : ");
                    var index = Convert.ToInt32(Console.ReadLine());
                    index--;
                    
                    Rooms.RemoveAt(index);
              
                    Console.WriteLine("Room has been allocated to "+name+"\n Thank you ,Come back again !\n ");
                    
                  
                }



           }
                  // method deallocaterooms
           public void DeAllocateRooms()
           {
                  Console.Write("Enter s/d/f to check  which type rooms want to deallocate in hotel ");
                  var result = Console.ReadLine();
                  Console.WriteLine(" Enter room ID  do you want to deallocate ");
                  var result2 = Convert.ToInt32(Console.ReadLine());
                  Console.Write("Enter an index of deallocate room ID: ");
                  var index = Convert.ToInt32(Console.ReadLine());
                  index++;
            
                  Console.Write("Room has been deallocated \n thank you ");

                  Console.WriteLine("Room deallocated : room id - "+result2+ " room type - "+result);

               
           }
                   //method displayroomallocation
           public void DisplayRoomAllocation()
           {

               foreach (HotelRooms newroom in Rooms)
               {

                   Console.WriteLine("Available Rooms : " + " Room Id - " + newroom.roomId + " \tRoom Type - " + newroom.roomName);
                    
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

                        foreach (HotelRooms newroom in Rooms)
                        {

                            sw.WriteLine("Available Rooms : " + " Room Id - " + newroom.roomId + " \tRoom Type - " + newroom.roomName);

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

                //string path1 = @"D:\Filehandle\lhms_studentid.txt";
                string path1 = @"C:\Users\makum\OneDrive\Pictures\lhms_studentid.txt";
                string All_text = File.ReadAllText(path1);
                Console.WriteLine(All_text);
           
                string src = @"C:\Users\makum\OneDrive\Pictures\lhms_studentid.txt";
                string dest = @"C:\Users\makum\OneDrive\Pictures\lhms_studentidBackup.txt";
                File.Copy(src,dest);
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