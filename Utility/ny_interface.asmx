<?xml version="1.0" encoding="utf-8"?>
<wsdl:definitions xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:tns="http://tempuri.org/" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" targetNamespace="http://tempuri.org/" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="http://tempuri.org/">
      <s:element name="GetInterFace">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="MZ_CHAR" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="GetInterFaceResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="GetInterFaceResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="Get_First">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="flag" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="gs_cs" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="gs_gnh" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="gs_conn" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="Get_FirstResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="Get_FirstResult" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfString">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="string" nillable="true" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="nh_interface">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="String_input" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="nh_interfaceResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="nh_interfaceResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="TransByte">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="theTransByteStruct" type="tns:TransByteStruct" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="TransByteStruct">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="connkey" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="cmdnum" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="serial" type="s:long" />
          <s:element minOccurs="0" maxOccurs="1" name="expbyte" type="s:base64Binary" />
          <s:element minOccurs="0" maxOccurs="1" name="inSql" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="returnStr" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="issucess" type="s:boolean" />
        </s:sequence>
      </s:complexType>
      <s:element name="TransByteResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="1" maxOccurs="1" name="TransByteResult" type="tns:TransByteStruct" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="GetInterFaceSoapIn">
    <wsdl:part name="parameters" element="tns:GetInterFace" />
  </wsdl:message>
  <wsdl:message name="GetInterFaceSoapOut">
    <wsdl:part name="parameters" element="tns:GetInterFaceResponse" />
  </wsdl:message>
  <wsdl:message name="Get_FirstSoapIn">
    <wsdl:part name="parameters" element="tns:Get_First" />
  </wsdl:message>
  <wsdl:message name="Get_FirstSoapOut">
    <wsdl:part name="parameters" element="tns:Get_FirstResponse" />
  </wsdl:message>
  <wsdl:message name="nh_interfaceSoapIn">
    <wsdl:part name="parameters" element="tns:nh_interface" />
  </wsdl:message>
  <wsdl:message name="nh_interfaceSoapOut">
    <wsdl:part name="parameters" element="tns:nh_interfaceResponse" />
  </wsdl:message>
  <wsdl:message name="TransByteSoapIn">
    <wsdl:part name="parameters" element="tns:TransByte" />
  </wsdl:message>
  <wsdl:message name="TransByteSoapOut">
    <wsdl:part name="parameters" element="tns:TransByteResponse" />
  </wsdl:message>
  <wsdl:portType name="ny_interfaceSoap">
    <wsdl:operation name="GetInterFace">
      <wsdl:input message="tns:GetInterFaceSoapIn" />
      <wsdl:output message="tns:GetInterFaceSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="Get_First">
      <wsdl:input message="tns:Get_FirstSoapIn" />
      <wsdl:output message="tns:Get_FirstSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="nh_interface">
      <wsdl:input message="tns:nh_interfaceSoapIn" />
      <wsdl:output message="tns:nh_interfaceSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="TransByte">
      <wsdl:input message="tns:TransByteSoapIn" />
      <wsdl:output message="tns:TransByteSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="ny_interfaceSoap" type="tns:ny_interfaceSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="GetInterFace">
      <soap:operation soapAction="http://tempuri.org/GetInterFace" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="Get_First">
      <soap:operation soapAction="http://tempuri.org/Get_First" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="nh_interface">
      <soap:operation soapAction="http://tempuri.org/nh_interface" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="TransByte">
      <soap:operation soapAction="http://tempuri.org/TransByte" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="ny_interfaceSoap12" type="tns:ny_interfaceSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="GetInterFace">
      <soap12:operation soapAction="http://tempuri.org/GetInterFace" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="Get_First">
      <soap12:operation soapAction="http://tempuri.org/Get_First" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="nh_interface">
      <soap12:operation soapAction="http://tempuri.org/nh_interface" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="TransByte">
      <soap12:operation soapAction="http://tempuri.org/TransByte" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="ny_interface">
    <wsdl:port name="ny_interfaceSoap" binding="tns:ny_interfaceSoap">
      <soap:address location="http://222.247.54.146:8086/zz_cl_interface/ny_interface.asmx" />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>