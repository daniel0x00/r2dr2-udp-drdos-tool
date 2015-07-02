#!/user/bin/python

from scapy.all import *
import json

listenerPort="9000"
listenerProtocol="udp"
attackString="empiezaLanzadorDePeticiones"
configJson="config_example.json"

# Class to store one attack
class attackPacket:

	#
	ip_dst=""
	port_dst=""
	desc=""
	nTry=""
	packageData=""

	#
	def __init__(self,ip_r,desc_r,nTry_r,packageData_r):
		self.ip_dst=getIP(ip_r)
		self.port_dst=getPort(ip_r)
		self.desc=desc_r
		self.nTry=nTry_r
		self.packageData=packageData_r
	
	#
	def printAttackPacket(self):
		print "\tAttack target Data"
		print "\t\t- Destination IP Address: " + str(self.ip_dst)
		print "\t\t- Description: " + str(self.desc)
		print "\t\t- Number of tries: " + str(self.nTry)
		print "\t\t- Raw Data: " + str(self.packageData)

# Class to store JSON data 
class attackTarget:

	#	
	ip_src=""
	port_src=""
	mac_src=""
	mac_dst=""
	iface=""
	threads=""
	attackArray=[]

	#
	def __init__(self,fileName):
		ipPortString=jsonData(fileName,"ip_origen")
		self.ip_src=getIP(ipPortString)
		self.port_src=getPort(ipPortString)
		self.mac_src=jsonData(fileName,"mac_origen")
		self.mac_dst=jsonData(fileName,"mac_destino")
		self.iface=jsonData(fileName,"interfaz")
		self.threads=jsonData(fileName,"threads")
		self.attackArray=jsonAttackArray(fileName)

	#
	def printMainData(self):
		print "JSON Attack Target Main Data"
		print "\t- Source IP: " + str(self.ip_src)
		print "\t- Source MAC Address: " + str(self.mac_src)
		print "\t- Destination MAC Address: " + str(self.mac_dst)
		print "\t- Interface: " + str(self.iface)
		print "\t- Threads: " + str(self.threads)
		return 1

	#
	def printAttackArray(self):
		for i in range(len(self.attackArray)):
			self.attackArray[i].printAttackPacket()
		return 1

# Return IP identified from IP:Port formated string
def getIP(stringIP):
	findIP = re.compile('(?:[0-9]{1,3}\.){3}[0-9]{1,3}')
	ipItem = findIP.findall(stringIP)
	return str(ipItem[0])

# Return port identified from IP:Port formated string
def getPort(stringPort):
	findPort = re.compile(':[0-9]{1,4}')
	findCleanPort = re.compile('[0-9]{1,4}')
	portItem = findPort.findall(stringPort)
	cleanPortItem = findCleanPort.findall(portItem[0])
	return str(cleanPortItem[0])

# Packet callback
def customAction(attackR2DR2):
	def launchAttack(packet):
		if ( packet.haslayer(UDP) ) and ( packet[UDP].dport == 9000 ) and ( packet[Raw].load == attackString ) :
			print "Starting an attack"
			for i in range(len(attackR2DR2.attackArray)):
				attackPackage = Ether(dst=attackR2DR2.mac_dst,src=attackR2DR2.mac_src) \
					/IP(src=attackR2DR2.ip_src, \
					dst=attackR2DR2.attackArray[i].ip_dst)/ \
					UDP(sport=int(attackR2DR2.port_src), \
					dport=int(attackR2DR2.attackArray[i].port_dst))/ \
					str(attackR2DR2.attackArray[i].packageData)
				attackPackage.show()
				for x in range(attackR2DR2.attackArray[i].nTry):
					send(attackPackage)
	return launchAttack

# JSON main data parser
def jsonData(fileName,jsonKey):
	jsonFile = open(fileName)
	jsonData = json.load(jsonFile)
	if "datos" not in jsonData:
		print "An error happened parsing " + jsonKey + " on config file " + fileName + " Process will end now"
		exit
	jsonFile.close()
	return jsonData["datos"][jsonKey]

# JSON attack array parser
def jsonAttackArray(fileName):
	attackArray=[]
	pCounter=0
	jsonFile = open(fileName)
	jsonData = json.load(jsonFile)
	array = jsonData.itervalues().next()
	for i in range(len(array)):
		ip_src=array[i]["ip_destino"]
		desc=array[i]["descripcion"]
		nTry=array[i]["intentos"]
		for j in range(len(array[i]["paquete"])):
			pData=array[i]["paquete"][j]
			attackArray.insert(pCounter,attackPacket(ip_src,desc,nTry,pData))
			pCounter+=1
	jsonFile.close()
	return attackArray


# Load Config Json
print "Loading JSON with attack configuration"
attackR2DR2=attackTarget(configJson)
print "Loading finished. " + str(len(attackR2DR2.attackArray)) + " attacks will be lauched when activated"
# Sniffer
filterString=listenerProtocol+" port "+listenerPort
print "Listening on " + filterString
sniff(filter="udp and ( port 9000 )",prn=customAction(attackR2DR2))
