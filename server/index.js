var app = require('http').createServer(handler)
var io = require('socket.io')(app);
var fs = require('fs');

app.listen(5555);

function handler (req, res) {
  fs.readFile(__dirname + '/index.html',
  function (err, data) {
    if (err) {
      res.writeHead(500);
      return res.end('Error loading index.html');
    }

    res.writeHead(200);
    res.end(data);
  });
}


io.on('connection', function (socket) {
    console.log("hello", socket.id);

    socket.on('register_controller', function () {
        console.log("register controller");
        socket.join('controller');
    });

    socket.on('register_game', function () {
        console.log("register game");
        socket.join('game');
    });


    socket.on('disconnect', function () {
        console.log("disconnect",  socket.id);
    });

    socket.on('click', function (data) {
        io.to('game').emit("button", data);
        console.log("emituje do gry", data);
    });

     socket.on('points', function (data) {
        console.log("punkty", data);
    });
});