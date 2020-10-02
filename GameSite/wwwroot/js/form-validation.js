$(function () {
    // Initialize form validation on the game create form.
    // It has the name attribute "gameadd"
    $("form[name='gameadd']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            GameName: {
                required: true,
                minlength: 2
            },
            GameCreator: {
                required: true,
                minlength: 2
            },
            GenreId: {
                required: true,
                min: 1
            },
            ConsoleId: {
                required: true,
                min: 1
            },
            Price: {
                required: true,
                number: true
            },
            Description: "required",
            Photo: {
                required: true
            }
        },

        // Specify validation error messages
        messages: {
            GameName: {
                required: "Please enter your game name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            GameCreator: {
                required: "Please enter the game creator",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            GenreId: {
                required: "Please choose genre",
                min: "Please select one genre from the dropdown"
            },
            ConsoleId: {
                required: "Please choose console",
                min: "Please select one console from the dropdown"
            },
            Price: {
                required: "Please enter the price of the game",
                number: "Please enter numbers only"
            },
            Description: "Please enter description",
            Photo: {
                required: "Please enter the image you want",
            }
        },

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});
$(function () {
    // Initialize form validation on the game create form.
    // It has the name attribute "gameadd"
    $("form[name='gameedit']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            GameName: {
                required: true,
                minlength: 2
            },
            GameCreator: {
                required: true,
                minlength: 2
            },
            GenreId: {
                required: true,
                min: 1
            },
            ConsoleId: {
                required: true,
                min: 1
            },
            Price: {
                required: true,
                number: true
            },
            Description: "required",
            Photo: {
                required: true
            }
        },

        // Specify validation error messages
        messages: {
            GameName: {
                required: "Please enter your game name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            GameCreator: {
                required: "Please enter the game creator",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            GenreId: {
                required: "Please choose genre",
                min: "Please select one genre from the dropdown"
            },
            ConsoleId: {
                required: "Please choose console",
                min: "Please select one console from the dropdown"
            },
            Price: {
                required: "Please enter the price of the game",
                number: "Please enter numbers only"
            },
            Description: "Please enter description",
            Photo: {
                required: "Please enter the image you want",
            }
        },

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});
$(function () {
    // Initialize form validation on the game create form.
    // It has the name attribute "gameadd"
    $("form[name='consolecreate']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            ConsoleName: {
                required: true,
                minlength: 2
            },
            Description: "required"
        },

        // Specify validation error messages
        messages: {
            ConsoleName: {
                required: "Please enter your console name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            Description: "Please enter description",
        },

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});
$(function () {
    // Initialize form validation on the game create form.
    // It has the name attribute "gameadd"
    $("form[name='consoleedit']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            ConsoleName: {
                required: true,
                minlength: 2
            },
            Description: "required"
        },

        // Specify validation error messages
        messages: {
            ConsoleName: {
                required: "Please enter your console name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            Description: "Please enter description",
        },

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});
$(function () {
    // Initialize form validation on the game create form.
    // It has the name attribute "gameadd"
    $("form[name='genrecreate']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            GenreName: {
                required: true,
                minlength: 2
            },
            GenreDescription: "required"
        },

        // Specify validation error messages
        messages: {
            GenreName: {
                required: "Please enter your genre name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            GenreDescription: "Please enter description",
        },

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});
$(function () {
    // Initialize form validation on the game create form.
    // It has the name attribute "gameadd"
    $("form[name='genreedit']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            GenreName: {
                required: true,
                minlength: 2
            },
            GenreDescription: "required"
        },

        // Specify validation error messages
        messages: {
            GenreName: {
                required: "Please enter your genre name",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            GenreDescription: "Please enter description",
        },

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});