import 'package:flutter/material.dart';
import 'package:scan/shared/themes/app_images.dart';
import 'package:scan/shared/widgets/button.dart';

import '../../shared/themes/app_colors.dart';
import '../../shared/themes/app_text_styles.dart';
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
                  AppImages.logoUTFPR,
                  fit: BoxFit.fitHeight,
                ),
              ),
              Container(
                height: 1,
                color: Colors.grey.shade300,
              ),
              const DrawerTiles(
                imageAssetSouce: AppImages.qrCode,
                text: "Ler QR Code",
              ),
              DrawerTiles(
                imageAssetSouce: AppImages.destaque,
                text: "Notificar COVID-19",
                ontap: (){
                  Navigator.pushNamed(context, "notification");
                },
              ),
              const DrawerTiles(
                imageAssetSouce: AppImages.download,
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
                    const TextSpan(
                      text:
                          "Nosso objetivo é poder criar ações rápidas e seguras para prevenção de COVID\n\n\n",
                    ),
                    const TextSpan(
                      text:
                          "Faça a leitura do QR Code na entrada da sala e infome quantos horários você pretende ficar",
                    ),
                  ],
                ),
              ),
            ),
             Padding(
              padding: EdgeInsets.all(20),
              child: Image.asset(
                  AppImages.qrCode,
                  fit: BoxFit.fitHeight,
                ),
            ),
            Button(
              title: "Ler o QR Code",
              onTap: () {
                Navigator.pushNamed(context, "block");
              },
            ),
          ],
        ),
      ),
    );
  }
}
