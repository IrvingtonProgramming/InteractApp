
// Use Parse.Cloud.define to define as many cloud functions as you want.
// For example:
Parse.Cloud.define("hello", function(request, response) {
  response.success("Hello world!");
});

Parse.Cloud.beforeSave("Event", function(request, response) {
  uri = request.object.get("ImageUri");

  Parse.Cloud.httpRequest({
    method: 'HEAD',
    url: uri,
  }).then(function(httpResponse) {
    if(httpResponse.status == 404 || httpResponse.headers['Content-Type'].substring(0,6) != "image/") {
      request.object.set("ImageUri", "invalid");
    }
    response.success();
  }, function(httpResponse) {
    request.object.set("ImageUri", "invalid");
    response.success()
  });
});
