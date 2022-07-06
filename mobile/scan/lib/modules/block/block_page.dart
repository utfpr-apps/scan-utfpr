import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:scan/Api/Api.dart';
import 'package:scan/globals.dart';
import 'package:scan/models/ambientes_model.dart';
import 'package:scan/shared/widgets/button.dart';
import '../../models/checkin_post_model.dart';
import '../../shared/themes/app_colors.dart';
import '../../shared/themes/app_images.dart';
import '../../shared/themes/app_text_styles.dart';
import '../../shared/widgets/drawer_tiles.dart';

class BlockPage extends StatefulWidget {
  const BlockPage({Key? key}) : super(key: key);

  @override
  State<BlockPage> createState() => _BlockPageState();
}

class _BlockPageState extends State<BlockPage> {
  List<int> horarios = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
  final API _api = API();

  int _index = 0;
  @override
  Widget build(BuildContext context) {
    
    final AmbienteModel _getModel =
        ModalRoute.of(context)!.settings.arguments as AmbienteModel;
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
              DrawerTiles(
                isSelected: true,
                imageAssetSouce: AppImages.qrCode,
                text: "Ler QR Code",
                ontap: () {
                  Navigator.pushNamed(context, "scanner");
                },
              ),
              DrawerTiles(
                imageAssetSouce: AppImages.destaque,
                text: "Notificar COVID-19",
                ontap: () {
                  Navigator.pushNamed(context, "notification");
                },
              ),
              DrawerTiles(
                imageAssetSouce: AppImages.download,
                text: "Sair do app",
                ontap: () {
                  SystemNavigator.pop();
                },
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
                  text:
                      "Você está na sala ${_getModel.codigoSala} que você vai utilizar, cada bloco de tempo é de:",
                  children: [
                    TextSpan(
                        text: "\n50 min\n\n", style: AppTextStyles.bigBold),
                    const TextSpan(
                      text:
                          "Quantos blocos de horário você pretende utilizar nesta sala?",
                    ),
                  ],
                ),
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(20),
              child: SizedBox(
                height: 200,
                child: CupertinoPicker(
                  onSelectedItemChanged: (index) {
                    _index = index;
                  },
                  itemExtent: 70,
                  diameterRatio: 30,
                  looping: true,
                  children: horarios
                      .map(
                        (horario) => Center(
                          child: Text(horario.toString()),
                        ),
                      )
                      .toList(),
                ),
              ),
            ),
            Button(
              title: "Realizar check-in",
              onTap: () {
                print(_getModel.id!);
                CheckinsPostModel teste = CheckinsPostModel(
                  ambienteId: _getModel.id!,
                  quantidadeBlocos: _index,

                );

                _api.toCheckIn(teste,"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoibWF0aGV1c28uMjAyMEBhbHVub3MudXRmcHIuZWR1LmJyIiwibmFtZWlkIjoiYzJhNmZjZDQtZjNjNS00NDM3LTkwZjktY2VmM2MwZGQzMzIyIiwicm9sZSI6IkFMVU5PIiwibmJmIjoxNjU3MDYzMDI1LCJleHAiOjE2NTgyNzI2MjUsImlhdCI6MTY1NzA2MzAyNX0.FfdnpOog8BxlN8lXbI0KRa65aOQgUfk69ipWj8HNUeU" ).then((value) {
                  print(value.statusCode);
                 if(value.statusCode == 200)
                  {
                    Navigator.pushNamed(context, "success");
                  }
                
                });
              },
            )
          ],
        ),
      ),
    );
  }
}
