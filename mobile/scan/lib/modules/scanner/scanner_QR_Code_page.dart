import 'dart:io';

import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:lottie/lottie.dart';
import 'package:mobile_scanner/mobile_scanner.dart';

import '../../Api/Api.dart';

class QRViewExample extends StatefulWidget {
  const QRViewExample({Key? key}) : super(key: key);

  @override
  State<QRViewExample> createState() => _QRViewExampleState();
}

class _QRViewExampleState extends State<QRViewExample> {
  final GlobalKey qrKey = GlobalKey(debugLabel: 'QR');
  Barcode? result;
  //QRViewController? controller;

  // In order to get hot reload to work we need to pause the camera if the platform
  // is android, or resume the camera if the platform is iOS.

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          Column(
            children: <Widget>[
              Expanded(
                flex: 5,
                child: MobileScanner(
                    allowDuplicates: false,
                    onDetect: (barcode, args) {
                      if (barcode.rawValue == null) {
                        debugPrint('Failed to scan Barcode');
                      } else {
                        final String code = barcode.rawValue!;
                        API _api = API();
                        _api.hasAmbiente(code, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoibWF0aGV1c28uMjAyMEBhbHVub3MudXRmcHIuZWR1LmJyIiwibmFtZWlkIjoiYzJhNmZjZDQtZjNjNS00NDM3LTkwZjktY2VmM2MwZGQzMzIyIiwicm9sZSI6IkFMVU5PIiwibmJmIjoxNjU3MDYzMDI1LCJleHAiOjE2NTgyNzI2MjUsImlhdCI6MTY1NzA2MzAyNX0.FfdnpOog8BxlN8lXbI0KRa65aOQgUfk69ipWj8HNUeU").then(
                          (value) {
                            if (value.id != null) {
                              print("achei");
                              Navigator.pushReplacementNamed(context, "block",
                                  arguments: value);
                            } else {
                              print("Não achei");
                            }
                          },
                        );
                      }
                    }),
              ),
            ],
          ),
          SizedBox(
            width: MediaQuery.of(context).size.width,
            child:
                Lottie.asset("assets/anim/QR_Code_Scan.json", fit: BoxFit.none),
          ),
        ],
      ),
    );
  }
/*
  void _onQRViewCreated(QRViewController controller) {
    this.controller = controller;

    controller.scannedDataStream.listen(
      (scanData) {
        setState(
          () async {
            
          },
        );
      },
    );
  }

  @override
  void dispose() {
    controller?.dispose();

    super.dispose();
  }
  */
}
