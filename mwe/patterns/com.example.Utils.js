// Revealing Module Pattern Example
// "Static Methods"
var com = com || {};
com.example = com.example || {};

com.example.Utils = function () {
    
    var randomInt = function(lower, upper) {
        return Math.floor(upper * Math.random() + 1);
    };

    return {
        randomInt: randomInt
    };

} ();