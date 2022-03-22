import 'package:flutter/material.dart';

import '../../shared/themes/app_colors.dart';
import '../../shared/themes/app_text_styles.dart';
import '../../shared/widgets/drawer_tiles.dart';

class SuccessPage extends StatefulWidget {
  const SuccessPage({Key? key}) : super(key: key);

  @override
  State<SuccessPage> createState() => _SuccessPageState();
}

class _SuccessPageState extends State<SuccessPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: SafeArea(
        child: Drawer(
          child: Column(
            children: [
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 60, vertical: 25),
                child: Image.asset(
                  "assets/images/logos/logo_utfpr.png",
                  fit: BoxFit.fitHeight,
                ),
              ),
              Container(
                height: 1,
                color: Colors.grey.shade300,
              ),
              const DrawerTiles(
                icon: Icons.qr_code_scanner_rounded,
                text: "Ler QR Code",
              ),
              const DrawerTiles(
                icon: Icons.arrow_back_sharp,
                text: "Sair do app",
              ),
            ],
          ),
        ),
      ),
      appBar: AppBar(
        backgroundColor: AppColors.primary,
      ),
      body: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 50),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Center(
              child: RichText(
                textAlign: TextAlign.center,
                text: TextSpan(
                  style: AppTextStyles.normalRegular,
                  text: "Seu ",
                  children: [
                    TextSpan(text: "Scan ", style: AppTextStyles.normalBold),
                    TextSpan(
                      text: "foi realiazdo com sucesso!\n\n\n",
                    ),
                  ],
                ),
              ),
            ),
            const Padding(
              padding: EdgeInsets.all(20),
              child: Icon(
                Icons.qr_code_scanner,
                size: 200,
              ),
            ),
            ElevatedButton(
              onPressed: () {},
              child: Container(
                child: const Text(
                  "Ler o QR Code",
                  textAlign: TextAlign.center,
                ),
                width: 300,
              ),
            ),
          ],
        ),
      ),
    );
  }
}
