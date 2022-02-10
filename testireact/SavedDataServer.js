
const express = require('express')
const app = express()
const cors = require('cors')
const fs = require('fs')
let notes = [];
fs.readFile("apartmentsjson.txt", 'utf8', function(err, data) {
  if (err) throw err;
  console.log("ok"+data);
    notes=JSON.parse(data);
});
app.get('/', (req, res) => {
  
  res.json(notes);
})





const PORT = 3002
app.listen(PORT, () => {
  console.log(`Server running on port ${PORT}`)
})