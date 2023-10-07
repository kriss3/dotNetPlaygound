using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppRedis.ApiOperations.Data
{
	public class CharacterService
	{

		public async Task<IEnumerable<Character>> GetCharacterAsync() 
		{
			return await GetCharacterData();
		}

		private async Task<List<Character>> GetCharacterData()
		{
			List<Character> myCharacters = new List<Character>
			{
				new Character
				{
					Id = 1,
					LastName = "Flintstone",
					FirstName = "Fred",
					Occupation = "Mining Manager",
					Gender = "M",
					PictureUrl = "https://api4all.azurewebsites.net/images/flintstone/fred.png",
					Votes = 0
				},
				new Character
				{
					Id = 2,
					LastName = "Rubble",
					FirstName = "Barney",
					Occupation = "Mining Assistant",
					Gender = "M",
					PictureUrl = "https://api4all.azurewebsites.net/images/flintstone/barney.png",
					Votes = 0
				},
				new Character
				{
					Id = 3,
					LastName = "Rubble",
					FirstName = "Betty",
					Occupation = "Nurse",
					Gender = "F",
					PictureUrl = "https://api4all.azurewebsites.net/images/flintstone/betty.png",
					Votes = 0
				},
				new Character
				{
					Id = 4,
					LastName = "Flintstone",
					FirstName = "Wilma",
					Occupation = "Teacher",
					Gender = "F",
					PictureUrl = "https://api4all.azurewebsites.net/images/flintstone/wilma.png",
					Votes = 0
				},
				new Character
				{
					Id = 5,
					LastName = "Rubble",
					FirstName = "Bambam",
					Occupation = "Baby",
					Gender = "M",
					PictureUrl = "https://api4all.azurewebsites.net/images/flintstone/bambam.png",
					Votes = 0
				},
				new Character
				{
					Id = 6,
					LastName = "Flintstone",
					FirstName = "Pebbles",
					Occupation = "Baby",
					Gender = "M",
					PictureUrl = "https://api4all.azurewebsites.net/images/flintstone/pebbles.png",
					Votes = 0
				},
				new Character
				{
					Id = 7,
					LastName = "Flintstone",
					FirstName = "Dino",
					Occupation = "Pet",
					Gender = "F",
					PictureUrl = "https://api4all.azurewebsites.net/images/flintstone/dino.png",
					Votes = 0
				},
				new Character
				{
					Id = 8,
					LastName = "Mouse",
					FirstName = "Micky",
					Occupation = "Hunter",
					Gender = "M",
					PictureUrl = "https://api4all.azurewebsites.net/images/disney/MickyMouse.png",
					Votes = 0
				},
				new Character
				{
					Id = 9,
					LastName = "Duck",
					FirstName = "Donald",
					Occupation = "Sailor",
					Gender = "M",
					PictureUrl = "https://api4all.azurewebsites.net/images/disney/DonaldDuck.png",
					Votes = 0
				}
			};
			return await Task.FromResult(myCharacters);
		}
	}
}

