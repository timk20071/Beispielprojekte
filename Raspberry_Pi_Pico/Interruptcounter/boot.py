import digitalio
import board
import busio
import time
import adafruit_irremote
from lcd.lcd import LCD
from lcd.i2c_pcf8574_interface import I2CPCF8574Interface

"""
    Sobald der Infrarotempfänger ein Signal erhält, zählt er nach oben und gibt es am Display aus
"""

reset = digitalio.DigitalInOut(board.GP3)
reset.direction = digitalio.Direction.INPUT
r2 = digitalio.DigitalInOut(board.GP2)
r2.direction = digitalio.Direction.OUTPUT
r2.value = True

def r(): # Dient zum Wiederverbinden zum Conputer, da man sonst in Endlosschleife gefangen ist
    if not reset.value:
        exit(1)

button = digitalio.DigitalInOut(board.GP13)
button.direction = digitalio.Direction.INPUT

i = 0

sda, scl = board.GP8, board.GP9
i2c = busio.I2C(scl, sda)
lcd = LCD(I2CPCF8574Interface(i2c, 0x27), num_rows=2, num_cols=16) #If address 0x27 does not work try 0x3F
lcd.set_backlight(True)
while True:
    if not button.value:
        i += 1
    lcd.set_cursor_pos(0,0)
    lcd.print("Counter: " + str(i))
    lcd.set_cursor_pos(1,0)
    lcd.print("Signal: " + str(button))
    r()