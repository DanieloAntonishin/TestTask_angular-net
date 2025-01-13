const PROXY_CONFIG = [
  {
    context: ["/urlshortener", "/user"],
    target: "https://localhost:7169",
    secure: false,
  }
]

module.exports = PROXY_CONFIG;
