import 'package:check/shared/themes/app_colors.dart';
import 'package:check/shared/themes/app_text_styles.dart';
import 'package:flutter/material.dart';

import '../../shared/widgets/drawer_tiles.dart';

class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
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
                  text: "Bem vindo ao ",
                  children: [
                    TextSpan(text: "Scan\n\n", style: AppTextStyles.normalBold),
                    TextSpan(
                      text:
                          "Nosso objetivo é poder criar ações rápidas e seguras para prevenção de COVID\n\n\n",
                    ),
                    TextSpan(
                      text:
                          "Faça a leitura do QR Code na entrada da sala e infome quantos horários você pretende ficar",
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
