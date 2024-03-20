import distanzsensor
import board
import busio
import time
from lcd.lcd import LCD
from lcd.i2c_pcf8574_interface import I2CPCF8574Interface

"""
    Ein Ultraschallsensor misst die Distanz zum nächst erfassten Objekt, der Wert wird am Display ausgegeben
"""
sda, scl = board.GP0, board.GP1
i2c = busio.I2C(scl, sda)
lcd = LCD(I2CPCF8574Interface(i2c, 0x27), num_rows=2, num_cols=16) #If address 0x27 does not work try 0x3F
lcd.set_backlight(True)
while True:
    lcd.set_cursor_pos(0,0)
    lcd.print("Distanz:")
    lcd.set_cursor_pos(1,0)
    dist = distanzsensor.getdistanz()
    lcd.print(str(round(dist, 2)) + "cm")
    time.sleep(0.5)
    lcd.clear()