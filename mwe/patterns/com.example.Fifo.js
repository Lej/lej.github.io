// Revealing Prototype Pattern Example
// "Class Definition"
var com = com || {};
com.example = com.example || {};

com.example.Fifo = function (options) {
    this.queue = options.queue || [];
};

com.example.Fifo.prototype = function () {
    
    var enqueue = function (item) {
        return this.queue.push(item);
    };

    var dequeue = function () {
        return this.queue.shift();
    };

    var enqueueAll = function (items) {
        for (var i = 0; i < items.length; i++) {
            // Will not work since "this" would be changed, use call()
            // enqueue(items[i]);
            enqueue.call(this, items[i]);
        }
        return this.queue.length;
    };

    var toString = function () {
        return "[(Next)" + this.queue.toString() + "(Last)]";
    };

    return {
        enqueue: enqueue,
        enqueueAll: enqueueAll,
        dequeue: dequeue,
        toString: toString
    };
    
} ();