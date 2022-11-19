# humiditymonitory2

## Description

This app sends me a text message whenever the humidity in my area is less than 20.  It checks the humidity for this purpose hourly.

## Required Secrets
These are set up both to keep things private (like appId) and for configuration purposes (like zipCode).

### For the openweathermap API:
- zipCode
- appId

### For the SMTP client:
- smtpHost
- mailUser
- password

### For the text message:
- fromAddress
- recipient (this is the email version of the phone number, i.e., 5551234567@vtext.com for Verizon)
