///////////////////////////////////////////////////////////////////////////////
// IMPORTS
///////////////////////////////////////////////////////////////////////////////

#load "./build/scripts/imports.cake"





//////////////////////////////////////////////////////////////////////
// SOLUTION
//////////////////////////////////////////////////////////////////////

// Name
var appName = "Cake.AWS.EC2";

// Projects
var projectNames = new List<string>() 
{ 
    "Cake.AWS.EC2"
};





///////////////////////////////////////////////////////////////////////////////
// LOAD
///////////////////////////////////////////////////////////////////////////////

#load "./build/scripts/load.cake"