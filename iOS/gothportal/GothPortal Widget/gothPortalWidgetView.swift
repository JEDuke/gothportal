//
//  gothPortalWidgetView.swift
//  GothPortal WidgetExtension
//
//  Created by Ethan Duke on 12/22/22.
//

import Foundation
import SwiftUI

struct gothPortalWidgetView: View {

    var gothImage = UIImage()

    var body: some View {
        
        Image(uiImage: gothImage)
            .onAppear() {
                Api().loadData { (g) in
                    gothImage = g
                }
            }
    }
}
