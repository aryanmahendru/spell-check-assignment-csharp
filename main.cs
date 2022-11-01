// Spell Check Starter
// This start code creates two lists
// 1: dictionary: an array containing all of the words from "dictionary.txt"
// 2: aliceWords: an array containing all of the words from "AliceInWonderland.txt"


using System;
using System.Text.RegularExpressions;
using System.Threading;



class Program {

  
  public static void Main (string[] args) {

    // Load data files into arrays
    String[] dictionary = System.IO.File.ReadAllLines(@"data-files/dictionary.txt");
    String aliceText = System.IO.File.ReadAllText(@"data-files/AliceInWonderLand.txt");
    String[] aliceWords = Regex.Split(aliceText, @"\s+");
    for (int i = 0; i < aliceWords.Length; i++){
      aliceWords[i]=aliceWords[i].ToLower();
    }
    
    int LinearSearch(string[] dict,string sfind){
      for(int i=0;i<dict.Length;i++){
        if(sfind == dict[i]){
          return i;
          }
      }
      return -1;
    } 

   int BinarySearch(string[] dictt,string ssfind){
     int min=0;
     int max=dictt.Length-1;
     while(min<=max){
        int mid=(min+max)/2;
        int stringcompare=(string.Compare(dictt[mid],ssfind));
        if(stringcompare == 0){
          return mid;
        }
        else if(stringcompare == 1){
          max=mid-1;
        }

        else {
          min=mid+1;
        }

      }
      return -1;
    }
    

    bool loop=true;
    while (loop){  
      Console.WriteLine("1: Spell Check a Word (Linear Search)");
      Console.WriteLine("2: Spell Check a Word (Binary Search)");
      Console.WriteLine("3: Spell Check Alice In Wonderland (Linear Search)");
      Console.WriteLine("4: Spell Check Alice In Wonderland (Binary Search)");
      Console.WriteLine("5: Exit");
      string selection =Console.ReadLine();
      DateTime start = DateTime.Now;

      if(selection == "1"){
        Console.WriteLine("Please Enter a word to check");
        string readname=Console.ReadLine();
        string readname1=readname.ToLower();
        Console.WriteLine("Linear Search Starting: ");
        int index=LinearSearch(dictionary,readname1);
        DateTime endlinearsearch = DateTime.Now;
        TimeSpan ts =(endlinearsearch-start);
        if (index >= 0){
          Console.WriteLine(readname1 +" is found at dictionary at "+index+"("+ts.TotalSeconds+" seconds)");
        }
        else if (index == -1){
          Console.WriteLine(readname1+" is not found at dictionary ("+ts.TotalSeconds+" seconds)");
        }
      }

      if(selection == "2"){
        Console.WriteLine("Please Enter a word to check");
        string readn=Console.ReadLine();
        string readn1 = readn.ToLower();
        Console.WriteLine("Binary Search starting");
        int index1=BinarySearch(dictionary,readn1);
        DateTime endbinarysearch = DateTime.Now;
        TimeSpan ts1=(endbinarysearch-start);
        if(index1 >= 0){
          Console.WriteLine(readn1+" is in the dictionary at position "+index1+"("+ts1.TotalSeconds+" seconds)");
        }
        else if(index1 == -1){
          Console.WriteLine(readn1+" is not found at dictionary ("+ts1.TotalSeconds+" seconds)");
        }
      }

      int totalwords=aliceWords.Length;
      if(selection=="3"){
        Console.WriteLine("Linear Search Starting");
        int wordsfound=0;
        for(int c=0;c<aliceWords.Length;c++){
          int index2 = LinearSearch(dictionary,aliceWords[c]);
          if (index2 >= 0){
            wordsfound++;
          }
        }
        int wordsnotfound=totalwords-wordsfound;
        DateTime endlinearsearch1=DateTime.Now;
        TimeSpan ts2=(endlinearsearch1-start);
        Console.WriteLine("Number of words not found in dictionary: " + wordsnotfound+ "(" +ts2.TotalSeconds + " seconds)");


      }

      if(selection == "4"){
        Console.WriteLine("Binary Search Starting");
        int wordsfound1=0;
        for(int d=0;d<aliceWords.Length;d++){
          int index3= BinarySearch(dictionary,aliceWords[d]);
          if(index3>=0){
            wordsfound1++;
          }
        }
        int wordsnotfound1=totalwords-wordsfound1;
        DateTime endbinarysearch1=DateTime.Now;
        TimeSpan ts3=(endbinarysearch1-start);
        Console.WriteLine("Number of words not found in dictionary: "+wordsnotfound1+"("+ts3.TotalSeconds+" seconds)");
      }

      if(selection=="5"){
        Console.WriteLine("Bye");
        loop=false;
      }

    
    
    
    
    }










  }



  
}