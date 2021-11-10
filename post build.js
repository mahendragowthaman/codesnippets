
const path = require('path');
const fs = require('fs');
const util = require('util');

var appVersion = process.argv[2];


var basePath = path.join(__dirname, '/deploy/tstat');

console.log("appVersion:" + appVersion);

function renameDistFile(file, matchHash, fileType) {
  let oldPath = path.join(basePath, file);
  let newPath = path.join(basePath, matchHash[1] + '.' + appVersion + fileType);
  fs.rename(oldPath, newPath, function () { })
}

if (appVersion == null || appVersion == "" || appVersion == undefined) {
  console.log("Error in post build scripts: appVersion not defined");
}
else {

  const readDir = util.promisify(fs.readdir);
  console.log('\nRunning post-build tasks');

  let jsRegExp = /^([a-z-0-9]*).?([a-z0-9]*).js$/;
  let jsRegExpWithoutMinus = /^([a-z0-9]*).?([a-z0-9]*).js$/;

  let mapRegExp = /^([a-z-0-9]*).?([a-z0-9]*).js.map$/;
  let mapRegExpWithoutMinus = /^([a-z0-9]*).?([a-z0-9]*).js.map$/;

  readDir(basePath)
    .then(files => {
      files.forEach((file) => {
        let matchHashForJS = file.match(jsRegExp);
        if (matchHashForJS == null)
          matchHashForJS = file.match(jsRegExpWithoutMinus);

        if (matchHashForJS != null && path.extname(file) == '.js') {
          renameDistFile(file, matchHashForJS, '.js')
        }

        let matchHashForMap = file.match(mapRegExp);
        if (matchHashForMap == null)
          matchHashForMap = file.match(mapRegExpWithoutMinus);

        if (matchHashForMap != null && path.extname(file) == '.map') {
          renameDistFile(file, matchHashForMap, '.js.map')
        }

      });

      console.log('\Completed post-build tasks');
      updateIndexHtmlVersion(basePath + "/index.html", appVersion)

    }).catch(err => {
      console.log('Error with post build:', err);
    });
}

function updateIndexHtmlVersion(filePath, appVersion) {
  fs.readFile(filePath, 'utf8', function (err, data) {
    if (err) {
      return console.log(err);
    }
    var result = data.replaceAll("{version}", appVersion);

    fs.writeFile(filePath, result, 'utf8', function (err) {
      if (err) return console.log(err);
    });
  });
}

String.prototype.replaceAll = function(search, replacement) {
  var target = this;
  return target.replace(new RegExp(search, 'g'), replacement);
};
