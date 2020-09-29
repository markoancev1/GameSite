using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSite.Logger
{
    public class LoggerMessageDisplay
    {
        // Game Messages
        public const string GamesListed = "All games listed successfully!";
        public const string NoGamesInDB = "There is no games in the DB!";
        public const string GameFoundDisplayDetails = "Game was found in the DB, show the details of the game";
        public const string NoGameFound = "This is no game found in the DB!";
        public const string GameCreated = "New game is created in the DB";
        public const string GameNotCreated = "New game is not created in the DB";
        public const string GamesNotCreatedModelStateInvalid = "New game is NOT created in the DB, ModelState is not valid";
        public const string GameEdited = "Game is edited successfully";
        public const string GameNotEdited = "Game is not edited successfully";
        public const string GameEditNotFound = "Game for editting is not found in the DB";
        public const string GameEditErrorModelStateInvalid = "Game is not edited, ModelState is not valid";
        public const string GameDeleted = "Game is deleted successfully";
        public const string GameNotDeleted = "Game is not deleted successfully";
        public const string GameDeletedError = "Game is NOT deleted, error happend in process of deletion";

        // Genre Messages
        public const string GenresListed = "All genres listed successfully!";
        public const string NoGenresInDB = "There is no genres in the DB!";
        public const string GenreFoundDisplayDetails = "Genre was found in the DB, show the details of the genre";
        public const string NoGenreFound = "This is no genre found in the DB!";
        public const string GenreCreated = "New genre is created in the DB";
        public const string GenreNotCreatedModelStateInvalid = "New genre is NOT created in the DB, ModelState is not valid";
        public const string GenreEdited = "Genre is edited successfully";
        public const string GenreEditNotFound = "Genre for editting is not found in the DB";
        public const string GenreEditErrorModelStateInvalid = "Genre is not edited, ModelState is not valid";
        public const string GenreDeleted = "Genre is deleted successfully";
        public const string GenreDeletedError = "Genre is NOT deleted, error happend in process of deletion";

        // Console Messages
        public const string ConsolesListed = "All consoles listed successfully!";
        public const string NoConsolesInDB = "There is no consoles in the DB!";
        public const string ConsoleFoundDisplayDetails = "Console was found in the DB, show the details of the author";
        public const string NoConsoleFound = "This is no console found in the DB!";
        public const string ConsoleCreated = "New console is created in the DB";
        public const string ConsoleNotCreatedModelStateInvalid = "New console is NOT created in the DB, ModelState is not valid";
        public const string ConsoleEdited = "Console is edited successfully";
        public const string ConsoleEditErrorModelStateInvalid = "Console is not edited, ModelState is not valid";
        public const string ConsoleDeleted = "Console is deleted successfully";
        public const string ConsoleDeletedError = "Console is NOT deleted, error happend in process of deletion";

        // Category Messages
        public const string CategoriesListed = "All categories listed successfully!";
        public const string NoCategoriesInDB = "There is no categories in the DB!";
        public const string CategoryFoundDisplayDetails = "Category was found in the DB, show the details of the category";
        public const string NoCategoryFound = "This is no category found in the DB!";
        public const string CategoryCreated = "New category is created in the DB";
        public const string CategoryNotCreatedModelStateInvalid = "New category is NOT created in the DB, ModelState is not valid";
        public const string CategoryEdited = "Category is edited successfully";
        public const string CategoryEditErrorModelStateInvalid = "Category is not edited, ModelState is not valid";
        public const string CategoryDeleted = "Category is deleted successfully";
        public const string CategoryDeletedError = "Category is NOT deleted, error happend in process of deletion";

        // Upload Photo Messages
        public const string PhotoUploaded = "Photo is successfully uploaded";
        public const string PhotoUploadedError = "Photo is NOT uploaded";
        public const string PhotosListed = "All photos listed successfully!";
        public const string NoPhotosInDB = "There is no photos in the DB!";
        public const string PhotoFoundDisplayDetails = "Photo was found in the DB, show the details of the photo";
        public const string NoPhotoFound = "This is no photo found in the DB!";
        public const string PhotoCreated = "New photo is created in the DB";
        public const string PhotoNotCreatedModelStateInvalid = "New photo is NOT created in the DB, ModelState is not valid";
        public const string PhotoEdited = "Photo is edited successfully";
        public const string PhotoEditErrorModelStateInvalid = "Photo is not edited, ModelState is not valid";
        public const string PhotoDeleted = "Photo is deleted successfully";
        public const string PhotoDeletedError = "Photo is NOT deleted, error happend in process of deletion";

        // User Messages
        public const string UsersListed = "All users listed successfully!";
        public const string NoUsersInDB = "There is no user in the DB!";
        public const string RegisterUserModelStateValid = "User has been successfully registered";
        public const string RegisterUserModelStateValidError = "User has not been successfully registered";
        public const string LoginUserModelStateValid = "User has been successfully logged in";
        public const string LoginUserModelStateValidError = "User has not been successfully registered";
        public const string LogoutUser = "User has logged out";
        public const string UserDeleted = "User has been successfully deleted";
        public const string UserDeleteError = "Error while deleting user";

        //Role Messages

        public const string RolesListed = "All roles listed successfully!";
        public const string NoRolesInDB = "There are no roles in the DB!";
        public const string RoleCreated = "New role is created in the DB";
        public const string RolesNotCreatedModelStateInvalid = "New role is NOT created in the DB, ModelState is not valid";
        public const string RoleEdited = "The selected role has been edited successfully";
        public const string RoleEditError = "The selected role is NOT edited, ModelState is not valid";
        public const string RoleDeleted = "The selected role has been deleted successfully";
        public const string RoleDeleteError = "The selected role is NOT deleted, ModelState is not valid";

        // ShoppingCart Messages

        public const string ShoppingCartListed = "All games in the shopping cart listed successfully!";
        public const string GameAddedToShoppingCart = "A game has been added to your Shopping Cart";
        public const string GameDeletedFromShoppingCart = "The game has been deleted from the shopping cart";
    }
}

