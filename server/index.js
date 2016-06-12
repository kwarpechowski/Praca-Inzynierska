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

const CONTROLLER = 'controller';
const GAME = 'game';


io.on('connection', function (socket) {
    console.log("hello", socket.id);

    socket.on('register_controller', function () {
        console.log("register controller");
        socket.join(CONTROLLER);
    });

    socket.on('register_game', function () {
        console.log("register game");
        socket.join(GAME);
    });


    socket.on('disconnect', function () {
        console.log("disconnect",  socket.id);
    });

    socket.on('click', function (data) {
        io.to(GAME).emit("button", data);
        console.log("emituje do gry", data);
    });

    socket.on('points', function (data) {
        console.log("punkty", data);
    });

    socket.on('disable_button', function (data) {
      console.log("disable_button", data);
      //if(socket.rooms.indexOf(GAME) >= 0) {
        io.to(CONTROLLER).emit("disable_button", data);
      //}
    });

    socket.on('enable_button', function (data) {
      console.log("enable_button", data);
      //if(socket.rooms.indexOf(GAME) >= 0) {
        io.to(CONTROLLER).emit("enable_button", data);
      //}
    });

    socket.on('set_text', function (data) {
      console.log("set_text", data);
      //if(socket.rooms.indexOf(GAME) >= 0) {
        io.to(CONTROLLER).emit("set_text", data);
      //}
    });
});